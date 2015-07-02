#!/bin/bash

if [ ! $1 ==  ]; then
	cd $1
fi

for i in *; do
	if [[ "$i" == *.jpg ]] || 
	[[ $i == *.jpeg ]] ||
	[[ $i == *.png ]]; then	
	convert $i -resize 1024 $i
	fi
done
