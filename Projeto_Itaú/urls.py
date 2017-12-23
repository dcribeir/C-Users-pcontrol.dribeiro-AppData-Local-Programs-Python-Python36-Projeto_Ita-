# coding=utf-8

"""Projeto_Itaú URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/2.0/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.conf.urls import url, include
from django.contrib import admin
from django.conf import settings
from django.views.static import serve as serve_static
from django.conf.urls.static import static
from django.contrib.auth.views import login, logout

from Core import views
from catalog import views as views_catalog

urlpatterns = [
	url(r'^$', views.index, name='index'),
	url(r'^Contato/$', views.contato, name='contato'),
    url(r'^Entrar/$', login, {'template_name': 'login.html'}, name='login'),
    url(r'^Sair/$', logout, {'next_page': 'index'}, name='logout'),
    url(r'^Catalogo/', include('catalog.urls', namespace='catalog')),
    url(r'^Conta/', include('accounts.urls', namespace='accounts')),
    url(r'^Compras/', include('checkout.urls', namespace='checkout')),
    url(r'^admin/', admin.site.urls),
]

if settings.DEBUG:
    urlpatterns += static(
        settings.MEDIA_URL, document_root=settings.MEDIA_ROOT
    )
