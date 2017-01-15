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
		var loader = JSONLoader();		 	
		 	/*nie m dostępu poza loaderem do zmiennych znajdujacych sie w loaderze, 
		 	wiec trzeba wszystko, rotacje, skalowanie i dodanie do sceny zrobić w loaderze */
		 loader.load(nameOfObject,function ( geometry ) {   	 
	        var	texture = loadTexture(nameOfTexture);
	       	var material = loadMaterial(texture);
	    	this.pizza = mesh( geometry, material);
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
}

function Tomatoe(angle){

	this.segments = 32;
	this.radius = 50;
	this.nameOfTexture = 'tomatoesTexture.png';
	this.angle= angle;


	this.addTomatoe = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	tomatoe = mesh( geometry,material);
		scene.add(tomatoe);
		objects.push( tomatoe ); 
	}
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

		}, false);
	return handler;
}  

function createTomatoeHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	tomatoe = new Tomatoe(angle);
	 	tomatoe.addTomatoe();	
		}, false);
	return handler;
}  






