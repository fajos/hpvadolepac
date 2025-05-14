
// You can write more code here

/* START OF COMPILED CODE */

class Level extends Phaser.Scene {

	constructor() {
		super("Level");
		this.currentQuiz    = "quiz1";
  		this.currentAttempt = 0; 
	}

	/** @returns {void} */
	editorCreate() {

		// map
		const map = this.add.tilemap("map");
		map.addTilesetImage("tileset", "tileset");
		
		const bgm = this.sound.add("bgm", {loop: true});
		//stop all existing bgm to prevent looping on restart
		this.sound.stopAll();
		bgm.play();
		// spaceKey
		const spaceKey = this.input.keyboard.addKey(Phaser.Input.Keyboard.KeyCodes.SPACE);

		// leftKey
		const leftKey = this.input.keyboard.addKey(Phaser.Input.Keyboard.KeyCodes.LEFT);

		// rightKey
		const rightKey = this.input.keyboard.addKey(Phaser.Input.Keyboard.KeyCodes.RIGHT);

		// upKey
		const upKey = this.input.keyboard.addKey(Phaser.Input.Keyboard.KeyCodes.UP);

		// downKey
		const downKey = this.input.keyboard.addKey(Phaser.Input.Keyboard.KeyCodes.DOWN);

		// back_2
		const back_2 = this.add.image(577, 0, "back");
		back_2.scaleX = 0.14499182430378013;
		back_2.scaleY = 0.20015256639156226;
		back_2.setOrigin(0, 0);

		// back_1
		const back_1 = this.add.image(289, 0, "back");
		back_1.scaleX = 0.14499182430378013;
		back_1.scaleY = 0.20015256639156226;
		back_1.setOrigin(0, 0);

		// back_3
		const back_3 = this.add.image(834, 0, "back");
		back_3.scaleX = 0.14499182430378013;
		back_3.scaleY = 0.20015256639156226;
		back_3.setOrigin(0, 0);

		// image_1
		const image_1 = this.add.image(460, 284, "underground");
		image_1.scaleX = 0.3;
		image_1.scaleY = 0.1;

		// back1
		const back1 = this.add.image(0, 0, "back");
		back1.scaleX = 0.14499182430378013;
		back1.scaleY = 0.20015256639156226;
		back1.setOrigin(0, 0);

		// layer
		const layer = map.createLayer("Tile Layer 1", ["tileset"], 0, 0);

		// tree
		const tree = this.add.image(450, -25, "atlas-props", "tree");
		tree.scaleX = 2;
		tree.scaleY = 2;
		tree.setOrigin(0, 0);

		// quiz
		const quiz = this.physics.add.staticSprite(228, 110, "quiz");
		quiz.scaleX = 0.1;
		quiz.scaleY = 0.1;
		quiz.body.setSize(quiz.width*quiz.scaleX, quiz.height*quiz.scaleY);
		quiz.body.setOffset((quiz.width-quiz.width*quiz.scaleX) / 2, (quiz.height-quiz.height*quiz.scaleY) / 2);
		
		// quiz2
		const quiz2 = this.physics.add.staticSprite(328, 110, "quiz");
		quiz2.scaleX = 0.1;
		quiz2.scaleY = 0.1;
		quiz2.body.setSize(quiz2.width*quiz2.scaleX, quiz2.height*quiz2.scaleY);
		quiz2.body.setOffset((quiz2.width-quiz2.width*quiz2.scaleX) / 2, (quiz2.height-quiz2.height*quiz2.scaleY) / 2);
		
		// quiz3
		const quiz3 = this.physics.add.staticSprite(428, 110, "quiz");
		quiz3.scaleX = 0.1;
		quiz3.scaleY = 0.1;
		quiz3.body.setSize(quiz3.width*quiz3.scaleX, quiz3.height*quiz3.scaleY);
		quiz3.body.setOffset((quiz3.width-quiz3.width*quiz3.scaleX) / 2, (quiz3.height-quiz3.height*quiz3.scaleY) / 2);
		
		// quiz4
		const quiz4 = this.physics.add.staticSprite(528, 110, "quiz");
		quiz4.scaleX = 0.1;
		quiz4.scaleY = 0.1;
		quiz4.body.setSize(quiz4.width*quiz4.scaleX, quiz4.height*quiz4.scaleY);
		quiz4.body.setOffset((quiz4.width-quiz4.width*quiz4.scaleX) / 2, (quiz4.height-quiz4.height*quiz4.scaleY) / 2);
		
		// quiz5
		const quiz5 = this.physics.add.staticSprite(628, 110, "quiz");
		quiz5.scaleX = 0.1;
		quiz5.scaleY = 0.1;
		quiz5.body.setSize(quiz5.width*quiz5.scaleX, quiz5.height*quiz5.scaleY);
		quiz5.body.setOffset((quiz5.width-quiz5.width*quiz5.scaleX) / 2, (quiz5.height-quiz5.height*quiz5.scaleY) / 2);
		
		// virus
		const virus = this.physics.add.staticSprite(262, 110, "virus");
		virus.scaleX = 0.2;
		virus.scaleY = 0.2;
		virus.body.setSize(virus.width*virus.scaleX, virus.height*virus.scaleY);
		virus.body.setOffset((virus.width-virus.width*virus.scaleX) / 2, (virus.height-virus.height*virus.scaleY) / 2);
		
		// virus2
		const virus2 = this.physics.add.staticSprite(362, 110, "virus");
		virus2.scaleX = 0.2;
		virus2.scaleY = 0.2;
		virus2.body.setSize(virus2.width*virus2.scaleX, virus2.height*virus2.scaleY);
		virus2.body.setOffset((virus2.width-virus2.width*virus2.scaleX) / 2, (virus2.height-virus2.height*virus2.scaleY) / 2);

		// virus3
		const virus3 = this.physics.add.staticSprite(462, 110, "virus");
		virus3.scaleX = 0.2;
		virus3.scaleY = 0.2;
		virus3.body.setSize(virus3.width*virus3.scaleX, virus3.height*virus3.scaleY);
		virus3.body.setOffset((virus3.width-virus3.width*virus3.scaleX) / 2, (virus3.height-virus3.height*virus3.scaleY) / 2);
		
		// virus4
		const virus4 = this.physics.add.staticSprite(562, 110, "virus");
		virus4.scaleX = 0.2;
		virus4.scaleY = 0.2;
		virus4.body.setSize(virus4.width*virus4.scaleX, virus4.height*virus4.scaleY);
		virus4.body.setOffset((virus4.width-virus4.width*virus4.scaleX) / 2, (virus4.height-virus4.height*virus4.scaleY) / 2);
		
		// virus5
		const virus5 = this.physics.add.staticSprite(662, 110, "virus");
		virus5.scaleX = 0.2;
		virus5.scaleY = 0.2;
		virus5.body.setSize(virus5.width*virus5.scaleX, virus5.height*virus5.scaleY);
		virus5.body.setOffset((virus5.width-virus5.width*virus5.scaleX) / 2, (virus5.height-virus5.height*virus5.scaleY) / 2);

		// vaccine_center
		const vaccine_center = this.physics.add.staticSprite(850, 90, "Vaccine_centre_icon");
		vaccine_center.scaleX = 0.3;
		vaccine_center.scaleY = 0.3;
		vaccine_center.body.setSize(vaccine_center.width*vaccine_center.scaleX, vaccine_center.height*vaccine_center.scaleY);
		vaccine_center.body.setOffset((vaccine_center.width-vaccine_center.width*vaccine_center.scaleX) / 2, (vaccine_center.height-vaccine_center.height*vaccine_center.scaleY) / 2);

		// player
		const player = new Player(this, 68, 0, "girl.png");
		this.add.existing(player);
		player.flipY = false;

		// jump_button
		const jump_button = this.add.image(262, 170, "jump-button");
		jump_button.scaleX = 0.39899614692006335;
		jump_button.scaleY = 0.39899614692006335;
		jump_button.visible = false;
		jump_button.tintTopLeft = 16627125;

		// controllerJump
		const controllerJump = new ControllerButtonScript(jump_button);

		// fixedToCameraScript
		new FixedToCameraScript(jump_button);

		// right_button
		const right_button = this.add.image(70, 170, "right-button");
		right_button.scaleX = 0.39899614692006335;
		right_button.scaleY = 0.39899614692006335;
		right_button.tintTopLeft = 16627125;

		// controllerRight
		const controllerRight = new ControllerButtonScript(right_button);

		// fixedToCameraScript_1
		new FixedToCameraScript(right_button);

		// left_button
		const left_button = this.add.image(26, 170, "left-button");
		left_button.scaleX = 0.39899614692006335;
		left_button.scaleY = 0.39899614692006335;
		left_button.tintTopLeft = 16627125;

		// controllerLeft
		const controllerLeft = new ControllerButtonScript(left_button);

		// fixedToCameraScript_2
		new FixedToCameraScript(left_button);

		// lists
		const items = [virus,virus2,virus3,virus4,virus5];
		const enemies = [];

		// colliderPlayerVsLayer
		const colliderPlayerVsLayer = this.physics.add.collider(player, layer);

		// colliderEnemiesVsLayer
		const colliderEnemiesVsLayer = this.physics.add.collider(enemies, layer);

		// overlapPlayerVsItems
		const overlapPlayerVsItems = this.physics.add.overlap(player, items, this.pickItem, undefined, this);
		
		// quiz bubble overlaps
		const overlapPlayerVsQuiz = this.physics.add.overlap(player, quiz, this.startQuiz);
		const overlapPlayerVsQuiz2 = this.physics.add.overlap(player, quiz2, this.startQuiz2);
		const overlapPlayerVsQuiz3 = this.physics.add.overlap(player, quiz3, this.startQuiz3);
		const overlapPlayerVsQuiz4 = this.physics.add.overlap(player, quiz4, this.startQuiz4);
		const overlapPlayerVsQuiz5 = this.physics.add.overlap(player, quiz5, this.startQuiz5);
		
		//vaccine center
		const overlapPlayerVsCenter = this.physics.add.overlap(player, vaccine_center, this.winGame);
		
		this.layer = layer;
		this.player = player;
		this.controllerJump = controllerJump;
		this.jump_button = jump_button;
		this.controllerRight = controllerRight;
		this.right_button = right_button;
		this.controllerLeft = controllerLeft;
		this.left_button = left_button;
		this.map = map;
		this.spaceKey = spaceKey;
		this.leftKey = leftKey;
		this.rightKey = rightKey;
		this.upKey = upKey;
		this.downKey = downKey;
		this.items = items;
		this.enemies = enemies;

		this.events.emit("scene-awake");
	}

	/** @type {Phaser.Tilemaps.TilemapLayer} */
	layer;
	/** @type {Player} */
	player;
	/** @type {ControllerButtonScript} */
	controllerJump;
	/** @type {Phaser.GameObjects.Image} */
	jump_button;
	/** @type {ControllerButtonScript} */
	controllerRight;
	/** @type {Phaser.GameObjects.Image} */
	right_button;
	/** @type {ControllerButtonScript} */
	controllerLeft;
	/** @type {Phaser.GameObjects.Image} */
	left_button;
	/** @type {Phaser.Tilemaps.Tilemap} */
	map;
	/** @type {Phaser.Input.Keyboard.Key} */
	spaceKey;
	/** @type {Phaser.Input.Keyboard.Key} */
	leftKey;
	/** @type {Phaser.Input.Keyboard.Key} */
	rightKey;
	/** @type {Phaser.Input.Keyboard.Key} */
	upKey;
	/** @type {Phaser.Input.Keyboard.Key} */
	downKey;
	/** @type {Array<any>} */
	items;
	/** @type {Array<any>} */
	enemies;
	 /** @type {number} */
  	currentAttempt;

	/* START-USER-CODE */

	create() {
    		window.parent.postMessage(
  		{ event: "level_started", level: this.currentQuiz, attempt: 0 },
 		"*"
		);

    		this.editorCreate();
    		this.initColliders();
    		this.initCamera();
		  }
	initCamera() {

		const cam = this.cameras.main;
		cam.setBounds(0, 0, this.layer.width, this.layer.height);
	}


	update() {

		this.movePlayer();

		// fix player position
		this.player.x = Math.floor(this.player.x);

		// fix camera position
		const cam = this.cameras.main;

		// camera X follows the player
		cam.scrollX = Math.floor(this.player.x - cam.width / 2);

		// cameras Y moves to a sector of the world
		const row = Math.floor(this.player.y / cam.height);
		cam.scrollY = row * cam.height;
	}
	
	startQuiz = (player, quiz) => {
  		this.scene.launch('quiz1');
  		quiz.destroy();
  		this.scene.pause();
		}
	
	startQuiz2 = (player, quiz2) => {
		this.scene.launch('quiz2');
		quiz2.destroy();
		this.scene.pause();
	}
	
	startQuiz3 = (player, quiz3) => {
		this.scene.launch('quiz3');
		quiz3.destroy();
		this.scene.pause();
	}
	
	startQuiz4 = (player, quiz4) => {
		this.scene.launch('quiz4');
		quiz4.destroy();
		this.scene.pause();
	}
	
	startQuiz5 = (player, quiz5) => {
		this.scene.launch('quiz5');
		quiz5.destroy();
		this.scene.pause();
	}
	
	winGame = () => {

  /* 1. log quiz win only the FIRST time */
  if (!this.levelWinLogged) {              // --- guard
    window.parent.postMessage({
      event: 'level_completed',
      level: this.levelKey,                // "quiz1" .. "quiz5"
      attemptNumber: this.currentAttempt
    }, '*');
    this.levelWinLogged = true;
  }

  /* 2. log overall game completion (optional) */
  window.parent.postMessage({
     event: 'completed',
     level: 'game',
     attemptNumber: this.currentAttempt
  }, '*');

  this.scene.start('GameWin');
};


	movePlayer() {

		if (this.player.hurtFlag) {
			return;
		}

		const body = this.player.getBody();

		const jumpDown = this.upKey.isDown || this.spaceKey.isDown || this.controllerJump.isDown;
		const leftDown = this.leftKey.isDown || this.controllerLeft.isDown;
		const rightDown = this.rightKey.isDown || this.controllerRight.isDown;

		var vel = 150;

		if (leftDown) {

			this.player.body.velocity.x = -vel;
			this.player.flipX = true;

		} else if (rightDown) {

			this.player.body.velocity.x = vel;
			this.player.flipX = false;

		} else {

			this.player.body.velocity.x = 0;

			if (this.downKey.isDown) {

				this.player.play("player/idle/player-idle", true);

			} else {

				this.player.play("player/idle/player-idle", true);
			}
		}
	}

	initColliders() {

		this.map.setCollision([27, 29, 31, 33, 35, 37, 77, 81, 86, 87, 127, 129, 131, 133, 134, 135, 83, 84, 502, 504, 505, 529, 530, 333, 335, 337, 339, 366, 368, 262, 191, 193, 195, 241, 245, 291, 293, 295]);
		this.setTopCollisionTiles([35, 36, 84, 86, 134, 135, 366, 367, 368, 262]);
	}

	/**
	 * @param {Player} player
	 * @param {Phaser.GameObjects.Sprite} item
	 */
	pickItem(player, item) {
		this.add.existing(new FeedbackItem(this, item.x, item.y));
		item.destroy();
	}
	
	checkHouse(player, vaccine_center) {
		this.scene.sound.stopAll();
		this.scene.start('GameOver');
	}

	/**
	 * @param {number[]} tiles
	 */
	setTopCollisionTiles(tiles) {

		const tileSet = new Set(tiles);

		for (let x = 0; x < this.map.width; x++) {

			for (let y = 0; y < this.map.height; y++) {

				const tile = this.layer.getTileAt(x, y);

				if (tile && tileSet.has(tile.index)) {

					tile.setCollision(false, false, true, false);
				}
			}
		}
	}

	/* END-USER-CODE */
}

/* END OF COMPILED CODE */

// You can write more code here
