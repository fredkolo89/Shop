		function setBasicProperties(){
			setPizzaSize();
			setGriedientSize();
			setStartPositionGredient();
			setCamera();
			setControls();
			setCanvas();
			setScene();
			setLight();
			setRendering();

		}
		function setStartPositionGredient(){
			startPositionGredient={y:window.screen.availHeight - window.screen.availHeight /2,x:-window.screen.availWidth + window.screen.availWidth/4}
		}
		function setPizzaSize(){
			 sizePizza= { small:200,medium:300,big:400, presentSize:0}
		}
		function setGriedientSize(){
			 sizeGriedient= { half:Math.PI, whole:Math.PI*2 }
		}

		function createSaveHandler(nameElement){
			 document.getElementById(nameElement).addEventListener("click",function() {					
			saveText='pizza'+';'+presentPizzaSize+'\t';
			for(var i=0; i<objects.length;i++){					
				saveText+=objectsName[i]+';'+objects[i].position.y+';'+objects[i].position.x+';'+objectsAngle[i]+'\t';
			}
 					 				 
 			download(saveText, 'pizza.txt', 'text/plain');
 		 	},	false);
		}
	
	    function updateSize() {
		    var updatedSize = document.getElementById("myRange").value;
		    console.log(updatedSize);
		    intersects[ 0 ].object.scale.set(updatedSize,updatedSize,updatedSize);
		    document.getElementById("myRange").value=1.0;
   			 document.getElementById("rmenu").className = "hide";  
 		}
 		 function download(strData, strFileName, strMimeType) {
	   		 var D = document,
	        A = arguments,
	        a = D.createElement("a"),
	        d = A[0],
	        n = A[1],
	        t = A[2] || "text/plain";

    //build download link:
		    a.href = "data:" + strMimeType + "charset=utf-8," + escape(strData);


		    if (window.MSBlobBuilder) { // IE10
		        var bb = new MSBlobBuilder();
		        bb.append(strData);
		        return navigator.msSaveBlob(bb, strFileName);
		    } /* end if(window.MSBlobBuilder) */



		    if ('download' in a) { //FF20, CH19
		        a.setAttribute("download", n);
		        a.innerHTML = "downloading...";
		        D.body.appendChild(a);
		        setTimeout(function() {
		            var e = D.createEvent("MouseEvents");
		            e.initMouseEvent("click", true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
		            a.dispatchEvent(e);
		            D.body.removeChild(a);
		        }, 66);
		        return true;
		    }; /* end if('download' in a) */



		    //do iframe dataURL download: (older W3)
		    var f = D.createElement("iframe");
		    D.body.appendChild(f);
		    f.src = "data:" + (A[2] ? A[2] : "application/octet-stream") + (window.btoa ? ";base64" : "") + "," + (window.btoa ? window.btoa : escape)(strData);
		    setTimeout(function() {
		        D.body.removeChild(f);
		    }, 333);
		    return true;
		}
		  function getObjectClass(obj){
		   if (typeof obj != "object" || obj === null) return false;
		   else return /(\w+)\(/.exec(obj.constructor.toString())[1];
		}



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
 				console.log(lines);
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
   				 			tomatoe = new Tomatoe(words[3]);
	 						tomatoe.addTomatoe(words[1],words[2]);
   				 			break;
							case 'onion': 
							onion = new Onion(words[3]);
	 						onion.addOnion(words[1],words[2]);   				 			
   				 			break;
   				 			case 'salami':
   				 			salami = new Salami(words[3]);
	 						salami.addSalami(words[1],words[2]);   				 			
   				 			break;
   				 			case 'cheese':
   				 			cheese = new Cheese(words[3]);
	 						cheese.addCheese(words[1],words[2]);   				 			
   				 			break;
   				 			case 'ham':
   				 			ham = new Ham(words[3]);
	 						ham.addHam(words[1],words[2]);	   				 			
   				 			break;
   				 			case 'mozzarella':
   				 			mozzarella= new Mozzarella(words[3]);
	 						mozzarella.addMozzarella(words[1],words[2]);	   				 			
   				 			break;
   				 			case 'cucumber':
   				 			cucumber = new Cucumber(words[3]);
	 						cucumber.addCucumber(words[1],words[2]);   				 			
   				 			break;
   				 			case 'corn':
   				 			corn= new Corn(words[3]);
	 						corn.addCorn(words[1],words[2]);   				 			
   				 			break;
   				 		}   				 		 

				}
            }   
                reader.readAsText(file);    
            } 
        });
		}

		function setRendering(){

			renderer = createRenderer();
			renderer.setSize( 800, 600 );
			renderer.setClearColor( 0xf0f0f0 );
			renderer.setPixelRatio( window.devicePixelRatio );
			renderer.setSize( window.innerWidth, window.innerHeight );
			renderer.sortObjects = false;

			renderer.shadowMap.enabled = true;
			renderer.shadowMap.type = THREE.PCFShadowMap;
			renderer.domElement.addEventListener( 'mousemove', onDocumentMouseMove, false );
			renderer.domElement.addEventListener( 'mousedown', onDocumentMouseDown, false );
			renderer.domElement.addEventListener( 'mouseup', onDocumentMouseUp, false );

			controls.enabled = false;
			window.addEventListener( 'resize', onWindowResize, false );
		}


		function setCamera(){

			camera = createCamera();
			camera.position.z = 1000;
		}

		function setCanvas(){
			container = document.getElementById('canvas') ;
		}

		function setScene(){
			scene = createScene();
		}
		function setLight(){			
			var light = createSpotLight();
			light.position.set( 0, 500, 2000 );
			light.castShadow = true;
			light.shadow = createLightShadow();
			light.shadow.bias = - 0.00022;
			light.shadow.mapSize.width = 2048;
			light.shadow.mapSize.height = 2048;

			scene.add( light );
			var lightAmbient = createAmbientLight();
			scene.add(lightAmbient);
		}

		function setControls(){
			controls = createTrackballControls(camera);
			controls.rotateSpeed = 1.0;
			controls.zoomSpeed = 1.2;
			controls.panSpeed = 0.8;
			controls.noZoom = false;
			controls.noPan = false;
			controls.staticMoving = true;
			controls.dynamicDampingFactor = 0.3;
		}

		function onWindowResize() {

				camera.aspect = window.innerWidth / window.innerHeight;
				camera.updateProjectionMatrix();
				renderer.setSize( window.innerWidth, window.innerHeight );

		}

		function onDocumentMouseMove( event ) {

			event.preventDefault();
			mouse.x = ( event.clientX / window.innerWidth ) * 2 - 1;
			mouse.y = - ( event.clientY / window.innerHeight ) * 2 + 1;
			raycaster.setFromCamera( mouse, camera );
			if ( SELECTED ) {
				if ( raycaster.ray.intersectPlane( plane, intersection ) ) {
					SELECTED.position.copy( intersection.sub( offset ) );
				}
			return;
			}

			var intersects = raycaster.intersectObjects( objects );

			if ( intersects.length > 0   ) {

				if ( INTERSECTED != intersects[ 0 ].object ) {

					if ( INTERSECTED ) INTERSECTED.material.color.setHex( INTERSECTED.currentHex );

						INTERSECTED = intersects[ 0 ].object;
						INTERSECTED.currentHex = INTERSECTED.material.color.getHex();

						plane.setFromNormalAndCoplanarPoint(
							camera.getWorldDirection( plane.normal ),
							INTERSECTED.position );

					}

					container.style.cursor = 'pointer';

				} else {

					if ( INTERSECTED ) INTERSECTED.material.color.setHex( INTERSECTED.currentHex );

					INTERSECTED = null;

					container.style.cursor = 'auto';

				}

			}
				var intersects ;
			function onDocumentMouseDown( event ) {

				event.preventDefault();

				raycaster.setFromCamera( mouse, camera );

				  intersects = raycaster.intersectObjects( objects );

					 
				switch ( event.button ) {
				    case 0: 
				    if ( intersects.length > 0 ) {

					SELECTED = intersects[ 0 ].object;
 
					if ( raycaster.ray.intersectPlane( plane, intersection ) ) {    			 	
	    			 	 	 
	    				 offset.copy( intersection ).sub( SELECTED.position ); 			 		 
					}
					container.style.cursor = 'move';
					}
				        break;
				    case 1: // middle

				     if ( intersects.length > 0 ) {
					 	document.getElementById("rmenu").className = "show";  
           				 document.getElementById("rmenu").style.top =   event.clientY + 'px';
          			 	 document.getElementById("rmenu").style.left =  event.clientX   + 'px';		
 					}										

				        break;
				    case 2: 
				       if ( intersects.length > 0 ) {

					SELECTED = intersects[ 0 ].object; 
					scene.remove( intersects[ 0 ].object );
					objects.splice(intersects[ 0 ].object, 1);				
				}				     
				        break;
				}				
			}

			function onDocumentMouseUp( event ) {

				event.preventDefault();

 				 
	    		SELECTED.position.x=limitDrag(SELECTED.position.x,sizePizza.presentSize);
	    		SELECTED.position.y=limitDrag(SELECTED.position.y,sizePizza.presentSize);

				if ( INTERSECTED ) {
					SELECTED = null;
				}
				container.style.cursor = 'auto';
			}

			function limitDrag(position, limit)
			{
 
				if(position>limit){
					return limit;
				}
				else if (position<(0-limit)) {
					return (0-limit);
				}
				else{
					return position;
				}
			}