srcIcon="${1}/Art/Public/Texture/General/APP_ICON.png"
desIcon="${1}/Art/Public/Texture/General/APP_ICON.png"
echo $srcIcon
echo $desIcon
/usr/local/bin/convert -size 192x192 xc:none -draw "roundrectangle 0,0,192,192,40,40" png:- | /usr/local/bin/convert $srcIcon -matte - -compose DstIn -composite $desIcon
