	 
		 
		var camera,container, pizzaObject ,controls, scene, renderer,sizePizza,sizeGriedient,pizza,
			objects = [],
		 	plane = createPlane(),
			raycaster = createRaycaster(),
		 	mouse = new THREE.Vector2(),
			offset = new THREE.Vector3(),
			intersection = new THREE.Vector3(),
			INTERSECTED, SELECTED;

	 	init();
		animate();


	 
		var small = createPizzaHandler('small',sizePizza.small);
  		var medium = createPizzaHandler('medium',sizePizza.medium);
		var big = createPizzaHandler('big',sizePizza.big);


		var tomatoes = createTomatoeHandler('tomatoe',sizeGriedient.whole);
		var halfTomatoe = createTomatoeHandler('halfTomatoe',sizeGriedient.half);

			 	
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