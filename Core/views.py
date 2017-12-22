# coding=utf-8

from django.shortcuts import render
from django.http import HttpResponse
from django.core.mail import send_mail
from django.conf import settings
from django.views.generic import View, TemplateView

from .forms import ContatoForm


class IndexView(TemplateView):
	
	template_name = 'index.html'

index = IndexView.as_view()
		

def contato(request):
	success = False
	form = ContatoForm(request.POST or None)
	if form.is_valid():
		form.send_mail()
		success = True
	else:
		form = ContatoForm()
	context = {
		'form': form,
		'success': success
	}
	return render(request, 'contato.html', context)
