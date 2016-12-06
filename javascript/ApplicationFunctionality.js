function createPizzaHandler(nameElement, size){	
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
	 	addPizza(size,scene);
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

function addPizza(size,scene){
	if(pizzaObject)
	{
 		scene.remove(pizzaObject);
	}
	sizePizza.presentSize = size;
	loadObject('pizza3d.json','pizza3d.jpg',size);	 
	showEndingElement('end','container');
	
}

function showEndingElement(nameElement, nameHidingElement){
	var end = createEndingElement(nameElement,nameHidingElement);
    document.getElementById(nameElement).style.display = 'block';
}

function createEndingElement(nameElement, nameHidingElement){
	var handler = document.getElementById(nameElement);
	handler.addEventListener("click",function() {
   		document.getElementById(nameHidingElement).style.display = 'none';
   		controls.enabled = true;
   	}, false);
	return handler;
}

function loadObject(nameOfObject, nameOfTexture,size ){
	var loader = new THREE.JSONLoader();

	
	loader.load(nameOfObject,function ( geometry ) {   	 
        var	texture = new THREE.ImageUtils.loadTexture(nameOfTexture);
       	var material = new THREE.MeshBasicMaterial({map: texture});
    	pizzaObject = new THREE.Mesh( geometry, material);
   		setSizeAndRotation(pizzaObject,size);	  
   		scene.add(pizzaObject); 		
		});			
	
}

function setSizeAndRotation(mesh,size){
	mesh.scale.set(size,200,size);
   	rotateObject(mesh, 90,0,0);
   	mesh.position.z = -320;		
}

function rotateObject(object,degreeX=0, degreeY=0, degreeZ=0){
	degreeX = (degreeX * Math.PI)/180;
    degreeY = (degreeY * Math.PI)/180;
	degreeZ = (degreeZ * Math.PI)/180;

	object.rotateX(degreeX);
	object.rotateY(degreeY);
	object.rotateZ(degreeZ);
}