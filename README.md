# WaveDeformer
Unity meshplane wave deformer.
![alt tag](https://github.com/jeroenboumans/WaveDeformer/blob/master/img/def_after.png)
## Sample setup Image container
```
$img = array (
	high-res-url  => "http://localhost/wp-content/uploads/2015/08/IMG_1475.jpg",
	low-res-url   => "http://localhost/wp-content/uploads/2015/08/IMG_1475-200x300.jpg)"
);
```

```
<div class="image" data-highres="<?php echo $img['high-res-url']; ?>" style="background-image:url('.$img['low-res-url'].');"></div>

```
## Motivation

This was build for making high-res images shown on my portfolio based on the Netflix resolution upscaling functionality. 

## Installation

Include de .js file in your head in combination with jQuery. Create an element with the class "image". The .image will have it's background image replaced by the url provided in it's data-highres attribute.
