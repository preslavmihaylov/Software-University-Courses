#!/bin/bash

if [ ! $1 == "" ]; then
	cd $1
fi

for i in *; do
	if [[ $i =~ .*[0-9]+.gz ]]; then
		logNum=$(echo $i | awk 'BEGIN { FS="."} { print ++$2 }')

		if [ $logNum -ge "13" ]; then
			rm $i
		else
			output=$(echo $i | sed "s/[0-9]\{1,\}/$logNum/g" )
			mv $i $output
		fi
	else
		gzip -S ".1.gz" "$i"
	fi		
done
