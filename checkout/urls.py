# coding=utf-8

from django.conf.urls import url

from . import views

urlpatterns = [
	url(
		r'^Carrinho/Adicionar/(?P<slug>[\w_-]+)/$', views.create_cartitem, 
		name='create_cartitem'
	),
	url(r'^Carrinho/$', views.cart_item, name='cart_item'),
	url(r'^finalizando/$', views.checkout, name='checkout'),
	url(r'^Histórico-de-Pedidos/$', views.order_list, name='order_list')
]
