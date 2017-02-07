

function Pizza(size){
	this.nameGredient = 'pizza';
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
			var myObj, myJSON, text, obj; 
	}

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
	this.nameGredient = 'tomatoe';
	this.segments = 32;
	this.radius = 50;
	this.nameOfTexture = 'grafiki/tomatoesTexture.png';
	this.angle= angle;
	

	this.addTomatoe = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	tomatoe = mesh( geometry,material);
		tomatoe.position.y = y;
		tomatoe.position.x =x;
		scene.add(tomatoe);
		objects.push(tomatoe); 
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);

		// saveText+=this.nameGredient+';'+tomatoe.position.y+';'+tomatoe.position.x+';\t';
	}

}

function Onion(angle){
	this.nameGredient = 'onion';
	this.segments = 32;
	this.radius = 40;
	this.nameOfTexture = 'grafiki/onionTexture.png';
	this.angle= angle;


	this.addOnion = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	onion = mesh( geometry,material);
		onion.position.y = y;
		onion.position.x =x;

		scene.add(onion);
		objects.push( onion ); 
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);
		// saveText+=this.nameGredient+';'+onion.position.y+';'+onion.position.x+';\t';

	}
}

function Salami(angle){
	this.nameGredient = 'salami';
	this.segments = 32;
	this.radius = 50;
	this.nameOfTexture = 'grafiki/salamiTexture.png';
	this.angle= angle;


	this.addSalami = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	salami = mesh( geometry,material);
		salami.position.y = y;
		salami.position.x =x ;
		scene.add(salami);
		objects.push( salami ); 
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);
		// saveText+=this.nameGredient+';'+salami.position.y+';'+salami.position.x+';\t';

	}
}

function Cheese(angle){
	this.nameGredient = 'cheese';
	this.segments = 32;
	this.radius = 70;
	this.nameOfTexture = 'grafiki/cheeseTexture.png';
	this.angle= angle;


	this.addCheese = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	cheese = mesh( geometry,material);
		cheese.position.y = y;
		cheese.position.x =x ;
		scene.add(cheese);
		objects.push( cheese ); 
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);
				// saveText+=this.nameGredient+';'+cheese.position.y+';'+cheese.position.x+';\t';

	}
}

function Ham(angle){
	this.nameGredient = 'ham';
	this.segments = 32;
	this.radius = 100;
	this.nameOfTexture = 'grafiki/hamTexture.png';
	this.angle= angle;


	this.addHam = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	ham = mesh( geometry,material);
		ham.position.y =y;
		ham.position.x =x ;
		scene.add(ham);
		objects.push( ham ); 
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);
				// saveText+=this.nameGredient+';'+ham.position.y+';'+ham.position.x+';\t';

	}
}

function Mozzarella(angle){
	this.nameGredient = 'mozzarella';
	this.segments = 32;
	this.radius = 60;
	this.nameOfTexture = 'grafiki/mozzarellaTexture.png';
	this.angle= angle;


	this.addMozzarella = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	mozzarella = mesh( geometry,material);
		mozzarella.position.y = y;
		mozzarella.position.x =x;
		scene.add(mozzarella);
		objects.push( mozzarella );
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);
				// saveText+=this.nameGredient+';'+mozzarella.position.y+';'+mozzarella.position.x+';\t';
 
	}
}

function Cucumber(angle){
	this.nameGredient = 'cucumber';
	this.segments = 32;
	this.radius = 30;
	this.nameOfTexture = 'grafiki/cucumberTexture.png';
	this.angle= angle;


	this.addCucumber = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	cucumber = mesh( geometry,material);
		cucumber.position.y = y;
		cucumber.position.x =x ;
		scene.add(cucumber);
		objects.push( cucumber ); 
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);
				// saveText+=this.nameGredient+';'+cucumber.position.y+';'+cucumber.position.x+';\t';

	}
}

function Corn(angle){
	this.nameGredient = 'corn';
	this.segments = 32;
	this.radius = 10;
	this.nameOfTexture = 'grafiki/cornTexture.png';
	this.angle= angle;


	this.addCorn = function(y,x){	
		var texture = loadTexture(this.nameOfTexture);
		var material = loadMaterial(texture);
		var geometry = circle( this.radius, this.segments, this.angle);
		var	corn = mesh( geometry,material);
		corn.position.y = y;
		corn.position.x =x ;
		scene.add(corn);
		objects.push( corn ); 
		objectsName.push(this.nameGredient);
		objectsAngle.push(this.angle);
				// saveText+=this.nameGredient+';'+corn.position.y+';'+corn.position.x+';\t';

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
	 	presentPizzaSize=size;

		}, false);
	return handler;
}  

function createTomatoeHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	tomatoe = new Tomatoe(angle);
	 	tomatoe.addTomatoe(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  

function createOnionHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	onion = new Onion(angle);
	 	onion.addOnion(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  

function createSalamiHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	salami = new Salami(angle);
	 	salami.addSalami(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  

function createCheeseHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	cheese = new Cheese(angle);
	 	cheese.addCheese(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  

function createHamHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	ham = new Ham (angle);
	 	ham.addHam(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  

function createMozzarellaHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	mozzarella = new Mozzarella (angle);
	 	mozzarella.addMozzarella(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  

function createCucumberHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	cucumber = new Cucumber (angle);
	 	cucumber.addCucumber(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  

function createCornHandler(nameElement, angle){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	corn = new Corn (angle);
	 	corn.addCorn(startPositionGredient.y,startPositionGredient.x);	
		}, false);
	return handler;
}  




