# -*- coding: utf-8 -*-
# Generated by Django 1.11.4 on 2017-12-23 01:38
from __future__ import unicode_literals

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('catalog', '0001_initial'),
        ('checkout', '0001_initial'),
    ]

    operations = [
        migrations.AlterUniqueTogether(
            name='cartitem',
            unique_together=set([('cart_key', 'product')]),
        ),
    ]
