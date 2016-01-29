#!/bin/bash

if [ $1 == "" ]; then
	echo "A text file must be specified"
	exit 0;
fi

output=""

while read line; do
	date=$(echo $line | cut -d '|' -f2| sed -e 's/-/ /g' -e 's/:/ /g')
	timestamp=$(echo "$date"| awk -v date="$date" '{ print mktime(date) }')
	now=$(date +%s)
	result=$(expr $now - $timestamp)
 
	if [ ! $result -gt "1209600" ]; then
		output="${output}${line}\n"		
	fi	
done <$1

echo -e $output| sort -t '|' -k2
