rev1=`/opt/subversion/bin/svnversion |sed 's/^.*://' |sed 's/[A-Z]*$//'`

srcIcon="${1}/Art/Public/Texture/General/APP_ICON.png"
desIcon="${1}/Art/Public/Texture/General/TestVersion/APP_ICON.png "

width=`/usr/local/bin/identify -format %w $srcIcon`
height=`/usr/local/bin/identify -format %h $srcIcon`

fontSize=$(($width / 4))
labelPosition=$((($height * 60) / 100))
lableHeight=$(($height-$labelPosition))
labelOffset=$((($lableHeight-$fontSize) / 2))

label="text 0,${labelOffset} '${rev1}"

/usr/local/bin/convert -fill "rgba(0,0,0,0.2)" -draw "rectangle 0,${labelPosition},${width},${height}" $srcIcon $desIcon
/usr/local/bin/convert -fill white -pointsize $fontSize -gravity center -gravity South -draw "${label}" $desIcon $desIcon