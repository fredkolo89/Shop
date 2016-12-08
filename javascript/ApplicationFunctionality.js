function Pizza(size){   /*  To jest definicja klasy  */

	this.size=size;
	this.nameOfObject = 'pizza3d.json';
	this.nameOfTexture = 'pizza3d.jpg';
	this.nameElement = 'end';
	this.nameHidingElement = 'container';
    this.pizza;

 
	this.addPizza = function(){
	    
		sizePizza.presentSize = size;
		this.loadObject(this.nameOfObject,this.nameOfTexture,this.size);	 
		this.showEndingElement(this.nameElement,this.nameHidingElement);
	
	};

	this.showEndingElement= function (nameElement, nameHidingElement){
		var end = this.createEndingElement(nameElement,nameHidingElement);
	    document.getElementById(nameElement).style.display = 'block';
	};

	this.createEndingElement= function (nameElement, nameHidingElement){
		var handler = document.getElementById(nameElement);
		handler.addEventListener("click",function() {
	   		document.getElementById(nameHidingElement).style.display = 'none';
	   		controls.enabled = true;
	   	}, false);
		return handler;
	};

	this.loadObject = function (nameOfObject, nameOfTexture,size ){
		var loader = new THREE.JSONLoader();
		 	
		 	/*nie m dostępu poza loaderem do zmiennych znajdujacych sie w loaderze, 
		 	wiec trzeba wszystko, rotacje, skalowanie i dodanie do sceny zrobić w loaderze */
		 loader.load(nameOfObject,function ( geometry ) {   	 
	        var	texture = new THREE.ImageUtils.loadTexture(nameOfTexture);
	       	var material = new THREE.MeshBasicMaterial({map: texture});
	    	this.pizza = new THREE.Mesh( geometry, material);
	    	this.pizza.scale.set(size,200, size);	   		
	   		degreeX = (90 * Math.PI)/180;
	  		degreeY = (0 * Math.PI)/180;
			degreeZ = (0 * Math.PI)/180;
			this.pizza.rotateX(degreeX);
			this.pizza.rotateY(degreeY);
			this.pizza.rotateZ(degreeZ);
	   		this.pizza.position.z = -320;	   		
	   		scene.add(this.pizza); 
		});		
	    		
	};

	// this.setSizeAndRotation=  function (size){
		 
	// 	this.pizza.scale.set(size,200,size);
	//    	this.rotateObject(this.pizza, 90,0,0);
	//    	this.pizza.position.z = -320;		
	// };
	// 	this.rotateObject =RotateObject;
	// 	 function RotateObject  (object,degreeX=0, degreeY=0, degreeZ=0){
	// 	degreeX = (degreeX * Math.PI)/180;
	//     degreeY = (degreeY * Math.PI)/180;
	// 	degreeZ = (degreeZ * Math.PI)/180;

	// 	object.rotateX(degreeX);
	// 	object.rotateY(degreeY);
	// 	object.rotateZ(degreeZ);
	// };

}


function createPizzaHandler(nameElement, size){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	
		if(pizza)
		{		
			scene.remove(pizza);
			delete pizza;	
		} 
	 	pizza = new Pizza(size);	 	
	 	pizza.addPizza();

	 	//addPizza(size,scene);
		}, false);
	return handler;
}  

function createTomatoeHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	addTomatoes(angle,objects,scene);
		}, false);
	return handler;
}  

function addTomatoes(angle,objects,scene){
 
	var segments = 32;
	var radius = 50;
	var texture = THREE.ImageUtils.loadTexture('tomatoesTexture.png');
	var	tomatoe = new THREE.Mesh( new THREE.CircleGeometry( radius, segments,0, angle ),
		new THREE.MeshBasicMaterial({map: texture}) );

	scene.add(tomatoe);
	objects.push( tomatoe ); 
}





