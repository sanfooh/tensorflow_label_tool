import hashlib
import io
import logging
import os
import random
import re

from lxml import etree
import PIL.Image
import tensorflow as tf

from object_detection.utils import dataset_util
from object_detection.utils import label_map_util


def get_examples(img_path):
    
    label_path =os.path.splitext(img_path)[0]+'.txt'
    if os.path.exists(test_file.txt) is False:
        return False,None
    
    with tf.gfile.GFile(img_path, 'rb') as fid:
        encoded_jpg = fid.read()
    encoded_jpg_io = io.BytesIO(encoded_jpg)
    image = PIL.Image.open(encoded_jpg_io)
    if image.format != 'JPEG':
        raise ValueError('Image format not JPEG')
    key = hashlib.sha256(encoded_jpg).hexdigest()    
    examples=[]
    for line in open(label_path):  
        data=line.split( )
        xmin = []
        ymin = []
        xmax = []
        ymax = []
        classes = []
        classes_text = []
        difficult_obj=[]
        truncated = []
        poses = []
        
        width=data[0]
        height=data[1]
        file_name=[2]
        image_format=[3]
        xmin.append(data[4])
        ymin.append(data[5])
        xmax.append(data[6])
        ymax.append(data[7])
        classes.append(data[8])
        classes_text.append(data[9])
        difficult_obj.append(0)
        truncated.append(0)
        poses.append('Unspecified')
        
        example = tf.train.Example(features=tf.train.Features(feature={
            'image/height': dataset_util.int64_feature(height),
          'image/width': dataset_util.int64_feature(width),
          'image/filename': dataset_util.bytes_feature(file_name.encode('utf8')),
          'image/source_id': dataset_util.bytes_feature(file_name.encode('utf8')),
          'image/key/sha256': dataset_util.bytes_feature(key.encode('utf8')),
          'image/encoded': dataset_util.bytes_feature(image_format.encode('utf8')),
          'image/format': dataset_util.bytes_feature('jpeg'.encode('utf8')),
          'image/object/bbox/xmin': dataset_util.float_list_feature(xmin),
          'image/object/bbox/xmax': dataset_util.float_list_feature(xmax),
          'image/object/bbox/ymin': dataset_util.float_list_feature(ymin),
          'image/object/bbox/ymax': dataset_util.float_list_feature(ymax),
          'image/object/class/text': dataset_util.bytes_list_feature(classes_text.encode('utf8')),
          'image/object/class/label': dataset_util.int64_list_feature(classes),
          'image/object/difficult': dataset_util.int64_list_feature(difficult_obj),
          'image/object/truncated': dataset_util.int64_list_feature(truncated),
          'image/object/view': dataset_util.bytes_list_feature(poses),
        }))
        examples.append(example)
    return True,examples    

def create_tf_record(examples_list,output_filename):
    writer = tf.python_io.TFRecordWriter(train_output_path)
    for i in examples_list:
        ret,examples=get_examples(examples_list[i])
        if ret:
            for i in examples:
                writer.write(tf_example.SerializeToString())
    writer.close()   

flags = tf.app.flags
flags.DEFINE_string('image_dir', '', 'Root directory to image')
flags.DEFINE_string('tfrecord_dir', '', 'Path to directory to output TFRecords.')
flags.DEFINE_float('example_percent', 0.7, 'split example to train and val percent')

def main(_):
    images=[]
    for (root,dirs,files) in os.walk(image_dir) :
        for item in files:
            if item.endwith('jpg'):
                images.append(os.path.join(root, item))
    
    random.seed(42)
    random.shuffle(images)
    num_examples = len(images)
    num_train = int(example_percent* num_examples)
    train_examples = examples_list[:num_train]
    val_examples = examples_list[num_train:]
    logging.info('%d training and %d validation examples.',len(train_examples), len(val_examples))
    
    train_output_path = os.path.join(FLAGS.tfrecord_dir, 'train.record')
    val_output_path = os.path.join(FLAGS.tfrecord_dir, 'val.record')
    
    create_tf_record(train_examples,train_output_path)
    create_tf_record(val_examples,val_output_path)
    logging.info('%d training and %d validation examples.')


if __name__ == '__main__':
    tf.app.run()