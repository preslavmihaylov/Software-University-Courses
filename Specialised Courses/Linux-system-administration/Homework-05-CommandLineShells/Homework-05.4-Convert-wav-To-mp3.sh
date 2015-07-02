#!/bin/bash

if [ ! $1 == "" ]; then
        cd $1;
fi

for i in *; do
	if [[ $i =~ .*\.wav ]]; then
		ffmpeg -i "$i" -f mp3 "${i%%.wav}.mp3";
	fi
done
