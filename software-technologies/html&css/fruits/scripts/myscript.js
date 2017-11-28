window.onload = choosePic;

var pictures = new Array("images/banana.png","images/kiwi.png","images/apple.png","images/orange.png");

function choosePic() {
     var randomNum = Math.floor(Math.random() * pictures.length);
	 var images = document.getElementsByTagName("img");
	 for (var i=0, len = images.length; i <len; i++){
		images[i].src= pictures[randomNum];
		randomNum = Math.floor(Math.random() * pictures.length);
		}
	}