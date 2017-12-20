# coding=utf-8

from django.shortcuts import render
from django.http import HttpResponse

#from catalog.models import Category

def index(request):
	return render(request, 'index.html')


def contato(request):
    return render(request, 'contato.html')


def produto(request):
    return render(request, 'produto.html')


#def produto_lista(request):
#    return render(request, 'produto_lista.html')