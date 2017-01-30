	 
		 
		var camera,container, pizzaObject ,controls, scene, renderer,sizePizza,sizeGriedient,pizza,
			objects = [],
		 	plane = createPlane(),
			raycaster = createRaycaster(),
		 	mouse = new THREE.Vector2(),
			offset = new THREE.Vector3(),
			intersection = new THREE.Vector3(),
			INTERSECTED, SELECTED;


	    var positionNewElement = document.getElementById('pizza').getBoundingClientRect();
		//console.log(rect.top, rect.right, rect.bottom, rect.left);

	 	init();
		animate();


	 
		var small = createPizzaHandler('small',sizePizza.small);
  		var medium = createPizzaHandler('medium',sizePizza.medium);
		var big = createPizzaHandler('big',sizePizza.big);


		var tomatoes = createTomatoeHandler('tomatoe',sizeGriedient.whole);
		var halfTomatoe = createTomatoeHandler('halfTomatoe',sizeGriedient.half);
		
		var onion = createOnionHandler('onion',sizeGriedient.whole);
		var halfOnion = createOnionHandler('halfOnion',sizeGriedient.half);
		
		var salami = createSalamiHandler('salami',sizeGriedient.whole);
		var halfSalami = createSalamiHandler('halfSalami',sizeGriedient.half);
		
		var cheese = createCheeseHandler('cheese',sizeGriedient.whole);
		
		var ham = createHamHandler('ham',sizeGriedient.whole);
		var halfHam = createHamHandler('halfHam',sizeGriedient.half);
		
		var mozzarella = createMozzarellaHandler('mozzarella',sizeGriedient.whole);
		var halfMozzarella = createMozzarellaHandler('halfMozzarella',sizeGriedient.half);
		
		var cucumber = createCucumberHandler('cucumber',sizeGriedient.whole);
		var halfCucumber = createCucumberHandler('halfCucumber',sizeGriedient.half);
		
		var corn = createCornHandler('corn',sizeGriedient.whole);
		
			 	
			function init() {				
				 
				setBasicProperties();
			}			

			function animate() {

				requestAnimationFrame( animate );

				render();			 

			}

			function render() {

				controls.update();

				renderer.render( scene, camera );

			}