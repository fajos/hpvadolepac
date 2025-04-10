
// You can write more code here

/* START OF COMPILED CODE */

class GameOver extends Phaser.Scene {

	constructor() {
		super("GameOver");

		/* START-USER-CTR-CODE */
		// Write your code here.
		/* END-USER-CTR-CODE */
	}

	/** @returns {void} */
	editorCreate() {

		// image_1
		const image_1 = this.add.image(149, 95, "blank_board");
		image_1.scaleX = 1.7;
		image_1.scaleY = 1.7;

		// gameOver
		const gameOver = this.add.text(39, 50, "", {});
		gameOver.text = "GAME OVER";
		gameOver.setStyle({ "fontFamily": "Press2Start", "fontSize": "36px" });

		// press_enter_text
		const press_enter_text = this.add.image(144, 124, "press-enter-text");

		this.press_enter_text = press_enter_text;

		this.events.emit("scene-awake");
	}

	/** @type {Phaser.GameObjects.Image} */
	press_enter_text;

	/* START-USER-CODE */

	// Write your code here

	create() {

		this.editorCreate();
		this.blinkText();

		//on enter or click, restart game
		this.input.keyboard.on('keydown-ENTER', this.startGame, this);
		this.input.on("pointerdown", (pointer) => this.startGame(), this);
	}

	blinkText() {

		this.time.addEvent({
			repeat: -1,
			delay: 1000,
			callback: () => {
				this.press_enter_text.visible = !this.press_enter_text.visible;
			}
		});
	}

	startGame() {
		this.scene.start("Level");
	}
	/* END-USER-CODE */
}

/* END OF COMPILED CODE */

// You can write more code here
