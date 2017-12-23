# coding=utf-8

from django.conf.urls import url

from . import views

urlpatterns = [
	url(r'^$', views.index, name='index'),
	url(r'^Alterar-Dados$', views.update_user, name='update_user'),
	url(r'^Alterar-Senhas$', views.update_password, name='update_password'),
	url(r'^registro$', views.register, name='register'),
	
]
