
// You can write more code here

/* START OF COMPILED CODE */

class TitleScreen extends Phaser.Scene {

	constructor() {
		super("TitleScreen");

		/* START-USER-CTR-CODE */
		// Write your code here.
		/* END-USER-CTR-CODE */
	}

	/** @returns {void} */
	editorCreate() {

		// background
		const background = this.add.tileSprite(0, 0, 384, 240, "back");
		background.setOrigin(0, 0);
		background.tileScaleX = 0.3;
		background.tileScaleY = 0.3;

		// middle
		const middle = this.add.tileSprite(0, 80, 384, 368, "middle");
		middle.scaleX = 0;
		middle.scaleY = 0;
		middle.setOrigin(0, 0);

		// title_screen
		const title_screen = this.add.image(144, 90, "title-screen");
		title_screen.scaleX = 0;
		title_screen.scaleY = 0;

		// credits_text
		const credits_text = this.add.image(144, 174, "credits-text");
		credits_text.visible = false;

		// press_enter_text
		const press_enter_text = this.add.image(144, 149, "press-enter-text");

		// title
		const title = this.add.text(43, 68, "", {});
		title.text = "VaccineQuest";
		title.setStyle({ "color": "#fea44bff", "fontFamily": "Atari", "fontSize": "36px", "stroke": "#330000ff", "strokeThickness":5});

		// instructions
		const instructions = this.add.image(149, 90, "blank_board");
		instructions.scaleX = 1.7;
		instructions.scaleY = 1.7;
		instructions.visible = false;

		// credits
		const credits = this.add.bitmapText(57, 168, "press2start", "Created using Phaser's \nbase platformer game");
		credits.text = "Created using Phaser's \nbase platformer game";
		credits.fontSize = 8;
		
		// instructions text
		const instructions_text = this.add.bitmapText(20, 40, "press2start", "Answer quiz questions to get\nto the vaccine center!");
		instructions_text.text = "Answer quiz questions\n to get to\nthe vaccine center!";
		instructions_text.fontSize = 12;
		instructions_text.visible = false;
		

		// startLevelAction
		const startLevelAction = new StartSceneActionScript(this);

		// startLevelAction (prefab fields)
		startLevelAction.sceneKey = "Level";

		this.background = background;
		this.middle = middle;
		this.title_screen = title_screen;
		this.press_enter_text = press_enter_text;
		this.instructions = instructions;
		this.instructions_text = instructions_text;
		this.startLevelAction = startLevelAction;

		this.events.emit("scene-awake");
	}

	/** @type {Phaser.GameObjects.TileSprite} */
	background;
	/** @type {Phaser.GameObjects.TileSprite} */
	middle;
	/** @type {Phaser.GameObjects.Image} */
	title_screen;
	/** @type {Phaser.GameObjects.Image} */
	press_enter_text;
	/** @type {Phaser.GameObjects.Image} */
	instructions;
	/** @type {StartSceneActionScript} */
	startLevelAction;

	/* START-USER-CODE */

	create() {
  this.editorCreate();

  this.input.keyboard.on("keydown-ENTER", this.enterPressed, this);
  this.input.on("pointerdown", this.enterPressed, this);

  this.blinkText();
}
	enterPressed() {

		if (this.title_screen.visible) {

			this.title_screen.visible = false;
			this.instructions.visible = true;
			this.instructions_text.visible = true;

		} else {

			this.startLevelAction.execute();
		}
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

	update() {

		this.background.tilePositionX += 0.3;
		this.middle.tilePositionX += 0.6;
	}

	/* END-USER-CODE */
}

/* END OF COMPILED CODE */

// You can write more code here
