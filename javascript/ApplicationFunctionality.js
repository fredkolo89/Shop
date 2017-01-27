function Pizza(size){

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

function Onion(angle){

	this.segments = 32;
	this.radius = 50;
	this.nameOfTexture = 'onionTexture.png';
	this.angle= angle;


	this.addOnion = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	onion = mesh( geometry,material);
		scene.add(onion);
		objects.push( onion ); 
	}
}

function Salami(angle){

	this.segments = 32;
	this.radius = 50;
	this.nameOfTexture = 'salamiTexture.png';
	this.angle= angle;


	this.addSalami = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	salami = mesh( geometry,material);
		scene.add(salami);
		objects.push( salami ); 
	}
}

function Cheese(angle){

	this.segments = 32;
	this.radius = 50;
	this.nameOfTexture = 'cheeseTexture.png';
	this.angle= angle;


	this.addCheese = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	cheese = mesh( geometry,material);
		scene.add(cheese);
		objects.push( cheese ); 
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

function createOnionHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	onion = new Onion(angle);
	 	onion.addOnion();	
		}, false);
	return handler;
}  

function createSalamiHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	salami = new Salami(angle);
	 	salami.addSalami();	
		}, false);
	return handler;
}  

function createCheeseHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	cheese = new Cheese (angle);
	 	cheese.addCheese();	
		}, false);
	return handler;
}  






