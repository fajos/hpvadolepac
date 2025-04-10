
// You can write more code here

/* START OF COMPILED CODE */

class GameWin extends Phaser.Scene {

	constructor() {
		super("GameWin");

		/* START-USER-CTR-CODE */
		// Write your code here.
		/* END-USER-CTR-CODE */
	}

	/** @returns {void} */
	editorCreate() {

		// image
		const image = this.add.image(149, 95, "blank_board");
		image.scaleX = 1.7;
		image.scaleY = 1.7;

		// win
		const win = this.add.bitmapText(34, 32, "press2start", "You've reached the\nvaccine center!");
		win.text = "You've reached the\nvaccine center!";
		win.fontSize = 12;
		win.align = 2;

		// share
		const share = this.add.bitmapText(64, 70, "press2start", "It's time to share\nwhat you've learned \nwith friends\nand family");
		share.text = "It's time to share\nwhat you've learned \nwith friends\nand family";
		share.fontSize = 8;
		share.align = 1;

		// press_enter_text
		const press_enter_text = this.add.image(139, 130, "press-enter-text");

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
		this.scene.start("TitleScreen");
	}
	/* END-USER-CODE */
}
/* END OF COMPILED CODE */

// You can write more code here
