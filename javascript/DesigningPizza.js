	 

		var camera,container, pizzaObject ,controls, scene, renderer,sizePizza,presentPizzaSize,sizeGriedient,startPositionGredient,pizza,
			objects = [],
			objectsName = [],
		 	plane = createPlane(),
			raycaster = createRaycaster(),
		 	mouse = new THREE.Vector2(),
			offset = new THREE.Vector3(),
			intersection = new THREE.Vector3(),
			INTERSECTED, SELECTED;

		var saveText='';


	    var positionNewElement = document.getElementById('pizza').getBoundingClientRect();

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
        

        var updatedSize=1;
		 function updateSize() {
		    updatedSize = document.getElementById("myRange").value;
		    console.log(updatedSize);
		    intersects[ 0 ].object.scale.set(updatedSize,updatedSize,updatedSize);
   			 document.getElementById("rmenu").className = "hide";  

 		}

		var save =  document.getElementById('save').addEventListener("click",function() {	
					
					saveText='pizza'+';'+presentPizzaSize+'\t';
					for(var i=0; i<objects.length;i++){
					
						saveText+=objectsName[i]+';'+objects[i].position.y+';'+objects[i].position.x+'\t';
					}
 					 				 
 			 		download(saveText, 'pizza.txt', 'text/plain');
 			 	},	false);		
	 
	  	
	
 		window.onload = function() {
        var fileInput = document.getElementById('fileInput');
        fileInput.addEventListener('change', function(e) {
            var file = fileInput.files[0];
            var textType = /text.*/;
            var loadText;
            if (file.type.match(textType)) {
                var reader = new FileReader();
                reader.onload = function(e) {
 				loadText= reader.result;
 				var lines = loadText.split('\t');
   				for(var line = 0; line < lines.length; line++){
   				 	var words = lines[line].split(';');
   				     console.log(words);
   				 		switch(words[0]){
   				 			case 'pizza':
   				 			if(pizza)
							{		
								scene.remove(pizza);
								delete pizza;	
						
							} 
						 	pizza = new Pizza(parseInt(words[1]));	 	
						 	pizza.addPizza();
						 	presentPizzaSize=parseInt(words[1]);
   				 			break;
   				 			case 'tomatoe':
   				 			tomatoe = new Tomatoe(sizeGriedient.whole);
	 						tomatoe.addTomatoe(words[1],words[2]);
   				 			break;
							case 'onion': 
							onion = new Onion(sizeGriedient.whole);
	 						onion.addOnion(words[1],words[2]);   				 			
   				 			break;
   				 			case 'salami':
   				 			salami = new Salami(sizeGriedient.whole);
	 						salami.addSalami(words[1],words[2]);   				 			
   				 			break;
   				 			case 'cheese':
   				 			cheese = new Cheese(sizeGriedient.whole);
	 						cheese.addCheese(words[1],words[2]);   				 			
   				 			break;
   				 			case 'ham':
   				 			ham = new ham(sizeGriedient.whole);
	 						ham.addHam(words[1],words[2]);	   				 			
   				 			break;
   				 			case 'mozzarella':
   				 			mozzarella= new Mozzarella(sizeGriedient.whole);
	 						mozzarella.addMozzarella(words[1],words[2]);	   				 			
   				 			break;
   				 			case 'cucumber':
   				 			cucumber = new Cucumber(sizeGriedient.whole);
	 						cucumber.addCucumber(words[1],words[2]);   				 			
   				 			break;
   				 			case 'corn':
   				 			corn= new Corn(sizeGriedient.whole);
	 						corn.addCorn(words[1],words[2]);   				 			
   				 			break;
   				 		}   				 		 

				}
            }   
                reader.readAsText(file);    
            } 
        });
		}

			 	
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