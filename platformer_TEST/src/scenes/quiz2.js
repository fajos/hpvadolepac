
// You can write more code here

/* START OF COMPILED CODE */

class quiz2 extends Phaser.Scene {

	constructor() {
		super("quiz2");

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

		// question
		const question = this.add.bitmapText(24, 30, "press2start", "What disease is caused by\nhuman papillamovirus?");
		question.text = "What disease is caused by\nhuman papillamovirus?";
		question.fontSize = 9;

		// q1
		const q1 = this.add.rectangle(84, 76, 140, 140);
		q1.setInteractive(new Phaser.Geom.Rectangle(0, 0, 140, 140), Phaser.Geom.Rectangle.Contains);
		q1.scaleX = 0.85;
		q1.scaleY = 0.3;
		q1.isFilled = true;
		q1.fillColor = 9995424;

		// q2
		const q2 = this.add.rectangle(208, 76, 140, 140);
		q2.setInteractive(new Phaser.Geom.Rectangle(0, 0, 140, 140), Phaser.Geom.Rectangle.Contains);
		q2.scaleX = 0.85;
		q2.scaleY = 0.3;
		q2.isFilled = true;
		q2.fillColor = 9995424;

		// q3
		const q3 = this.add.rectangle(84, 128, 140, 140);
		q3.setInteractive(new Phaser.Geom.Rectangle(0, 0, 140, 140), Phaser.Geom.Rectangle.Contains);
		q3.scaleX = 0.85;
		q3.scaleY = 0.3;
		q3.isFilled = true;
		q3.fillColor = 9995424;

		// q4
		const q4 = this.add.rectangle(208, 128, 140, 140);
		q4.setInteractive(new Phaser.Geom.Rectangle(0, 0, 140, 140), Phaser.Geom.Rectangle.Contains);
		q4.scaleX = 0.85;
		q4.scaleY = 0.3;
		q4.isFilled = true;
		q4.fillColor = 9995424;

		// text1
		const text1 = this.add.bitmapText(30, 64, "press2start", "Hepatitus");
		text1.text = "A.Hepatitus";
		text1.fontSize = 8;

		// text2
		const text2 = this.add.bitmapText(150, 64, "press2start", "Genital warts\nand\ncervical\ncancer");
		text2.text = "B.Genital warts\nand cervical\ncancer";
		text2.fontSize = 8;

		// text
		const text = this.add.bitmapText(30, 114, "press2start", "AIDS");
		text.text = "C.AIDS";
		text.fontSize = 8;

		// text_1
		const text_1 = this.add.bitmapText(150, 114, "press2start", "HIV");
		text_1.text = "D.HIV";
		text_1.fontSize = 8;
		
		// pointer down events
		q1.on('pointerdown', this.lose);
		q2.on('pointerdown', this.continue);
		q3.on('pointerdown', this.lose);
		q4.on('pointerdown', this.lose);

		this.events.emit("scene-awake");
	}

	/* START-USER-CODE */

	// Write your code here

	create() { this.editorCreate(); }

	// ----- player fails this quiz -----
	lose = () => {
  		const lvl = this.scene.get("Level");
  		lvl.currentAttempt += 1;

  		window.parent.postMessage(
    		{ event: 'retry', level: 'level2', attempt: lvl.currentAttempt },
    		'*'
  		);

  	// restart the *same* level
  		this.scene.stop("Level");
  		this.scene.start("Level", { levelKey: "level2" });
  		this.scene.stop();            // close quiz
		};

	// ----- player passes this quiz -----
	continue = () => {
  		// start next level fresh
  		this.scene.stop("Level");
  		this.scene.start("Level", { levelKey: "level3" });
  		this.scene.stop();            // close quiz
		};
	/* END-USER-CODE */
}

/* END OF COMPILED CODE */

// You can write more code here
