function loadTexture(nameOfTexture){

	return new THREE.ImageUtils.loadTexture(nameOfTexture);
}
function JSONLoader(){

	return new THREE.JSONLoader();
}
function loadMaterial(texture){

	return new THREE.MeshBasicMaterial({map: texture});
}
function mesh(geometry, material){

	return new THREE.Mesh( geometry, material);
}
function circle(radius,segments,angle){

	return new THREE.CircleGeometry( radius, segments,0, angle )
}
function createRenderer(){

	return new THREE.WebGLRenderer( { antialias: true, canvas: container} );
}
function createCamera(){

	return new THREE.PerspectiveCamera(70, window.innerWidth / window.innerHeight, 1, 10000);
}
function createScene(){

	return new THREE.Scene();
}
function createSpotLight(){

	return new THREE.SpotLight( 0xffffff, 1.5 );
}
function createLightShadow(){

	return new THREE.LightShadow( new THREE.PerspectiveCamera( 50, 1, 200, 10000 ) );
}
function createAmbientLight(){

	return  new THREE.AmbientLight( 0x505050 );
}
function createTrackballControls(camera){

	return new THREE.TrackballControls( camera );
}
function createPlane(){

	return new THREE.Plane();
}
function createRaycaster(){

	return new THREE.Raycaster();
}