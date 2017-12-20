# coding=utf-8


from django.conf.urls import url

from . import views

app_name  =  'catalog' 
urlpatterns = [
	url(r'^$', views.product_list, name='product_list'),
    path('<int:pk>/', views.DetailView.as_view(), name='detail'),
]
