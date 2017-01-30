function Pizza(size){

	this.size=size;
	this.nameOfObject = 'grafiki/pizza3d.json';
	this.nameOfTexture = 'grafiki/pizza3d.jpg';
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
	this.nameOfTexture = 'grafiki/tomatoesTexture.png';
	this.angle= angle;
	

	this.addTomatoe = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	tomatoe = mesh( geometry,material);
		tomatoe.position.y = 0+positionNewElement.bottom*1.5 ;
		console.log(positionNewElement.top, positionNewElement.right, positionNewElement.bottom, positionNewElement.left);
		tomatoe.position.x =-window.innerWidth + positionNewElement.right*2.5;
		tomatoe.rotateX = 30;
		scene.add(tomatoe);
		objects.push( tomatoe ); 
	}
}

function Onion(angle){

	this.segments = 32;
	this.radius = 40;
	this.nameOfTexture = 'grafiki/onionTexture.png';
	this.angle= angle;


	this.addOnion = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	onion = mesh( geometry,material);
		onion.position.x = -700;
		onion.position.y = 400;
		scene.add(onion);
		objects.push( onion ); 
	}
}

function Salami(angle){

	this.segments = 32;
	this.radius = 50;
	this.nameOfTexture = 'grafiki/salamiTexture.png';
	this.angle= angle;


	this.addSalami = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	salami = mesh( geometry,material);
		salami.position.x = -700;
		salami.position.y = 400;
		scene.add(salami);
		objects.push( salami ); 
	}
}

function Cheese(angle){

	this.segments = 32;
	this.radius = 70;
	this.nameOfTexture = 'grafiki/cheeseTexture.png';
	this.angle= angle;


	this.addCheese = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	cheese = mesh( geometry,material);
		cheese.position.x = -700;
		cheese.position.y = 400;
		scene.add(cheese);
		objects.push( cheese ); 
	}
}

function Ham(angle){

	this.segments = 32;
	this.radius = 100;
	this.nameOfTexture = 'grafiki/hamTexture.png';
	this.angle= angle;


	this.addHam = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	ham = mesh( geometry,material);
		ham.position.x = -700;
		ham.position.y = 400;
		scene.add(ham);
		objects.push( ham ); 
	}
}

function Mozzarella(angle){

	this.segments = 32;
	this.radius = 60;
	this.nameOfTexture = 'grafiki/mozzarellaTexture.png';
	this.angle= angle;


	this.addMozzarella = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	mozzarella = mesh( geometry,material);
		mozzarella.position.x = -700;
		mozzarella.position.y = 400;
		scene.add(mozzarella);
		objects.push( mozzarella ); 
	}
}

function Cucumber(angle){

	this.segments = 32;
	this.radius = 30;
	this.nameOfTexture = 'grafiki/cucumberTexture.png';
	this.angle= angle;


	this.addCucumber = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	cucumber = mesh( geometry,material);
		cucumber.position.x = -700;
		cucumber.position.y = 400;
		scene.add(cucumber);
		objects.push( cucumber ); 
	}
}

function Corn(angle){

	this.segments = 32;
	this.radius = 10;
	this.nameOfTexture = 'grafiki/cornTexture.png';
	this.angle= angle;


	this.addCorn = function(){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	corn = mesh( geometry,material);
		corn.position.x = -700;
		corn.position.y = 400;
		scene.add(corn);
		objects.push( corn ); 
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

function createHamHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	ham = new Ham (angle);
	 	ham.addHam();	
		}, false);
	return handler;
}  

function createMozzarellaHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	mozzarella = new Mozzarella (angle);
	 	mozzarella.addMozzarella();	
		}, false);
	return handler;
}  

function createCucumberHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	cucumber = new Cucumber (angle);
	 	cucumber.addCucumber();	
		}, false);
	return handler;
}  

function createCornHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	corn = new Corn (angle);
	 	corn.addCorn();	
		}, false);
	return handler;
}  




