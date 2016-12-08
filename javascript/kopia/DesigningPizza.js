	 
		 
		var camera,container, pizzaObject ,controls, scene, renderer,sizePizza,
			objects = [],
		 	plane = new THREE.Plane(),
			raycaster = new THREE.Raycaster(),
		 	mouse = new THREE.Vector2(),
			offset = new THREE.Vector3(),
			intersection = new THREE.Vector3(),
			INTERSECTED, SELECTED;

	 	init();
		animate();


	 
		var small = createPizzaHandler('small',sizePizza.small);
  		var medium = createPizzaHandler('medium',sizePizza.medium);
		var big = createPizzaHandler('big',sizePizza.big);


		var tomatoes = createTomatoeHandler('tomatoe',Math.PI*2);
		var halfTomatoe = createTomatoeHandler('halfTomatoe',Math.PI);

			 	
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