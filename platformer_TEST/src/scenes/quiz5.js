
// You can write more code here

/* START OF COMPILED CODE */

class quiz5 extends Phaser.Scene {

	constructor() {
		super("quiz5");

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
		const question = this.add.bitmapText(24, 30, "press2start", "The current HPV vaccine dosage uptake is?");
		question.text = "The current HPV vaccine\ndosage uptake is?";
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
		const q4 = this.add.rectangle(208, 127, 140, 140);
		q4.setInteractive(new Phaser.Geom.Rectangle(0, 0, 140, 140), Phaser.Geom.Rectangle.Contains);
		q4.scaleX = 0.85;
		q4.scaleY = 0.3;
		q4.isFilled = true;
		q4.fillColor = 9995424;

		// text1
		const text1 = this.add.bitmapText(30, 64, "press2start", "One dose for\n9-14 years");
		text1.text = "A.One dose for\n9-14 years";
		text1.fontSize = 8;

		// text2
		const text2 = this.add.bitmapText(150, 64, "press2start", "3 doses for\nimmunocompromised\npersons");
		text2.text = "B.3 doses for\nimmuno\ncompromised\npersons";
		text2.fontSize = 8;

		// text
		const text = this.add.bitmapText(30, 114, "press2start", "1-2 doses for ages\n15-50");
		text.text = "C.1-2 doses\nfor ages\n15-50";
		text.fontSize = 8;

		// text_1
		const text_1 = this.add.bitmapText(150, 114, "press2start", "All of the above");
		text_1.text = "D.All of the\nabove";
		text_1.fontSize = 8;
		
		// pointer down events
		q1.on('pointerdown', this.lose);
		q2.on('pointerdown', this.lose);
		q3.on('pointerdown', this.lose);
		q4.on('pointerdown', this.continue);

		this.events.emit("scene-awake");
	}

	/* START-USER-CODE */

	// Write your code here

	create() { this.editorCreate(); }

/* WRONG ANSWER --------------------------------------- */
lose = () => {
  const lvl = this.scene.get("Level");
  lvl.currentAttempt += 1;

  window.parent.postMessage(
    { event: "retry", level: lvl.currentQuiz, attempt: lvl.currentAttempt },
    "*"
  );

  // restart the whole game scene, same quiz target
  this.scene.stop("Level");
  this.scene.start("Level");   // currentQuiz & attempt stay in Level singleton
  this.scene.stop();
};

/* CORRECT ANSWER ------------------------------------- */
continue = () => {

  /* ---- tell parent this quiz was beaten ------------------ */
  window.parent.postMessage(
    { event: 'level_completed',
      level: this.scene.key,          // "quiz1" / "quiz2" / …
      attemptNumber: 0 },             // always 0 because you just won
    '*');

  /* ---- return to the platform level ---------------------- */
  this.scene.resume("Level");
  this.scene.stop();                  // close quiz popup
}

	/* END-USER-CODE */
}

/* END OF COMPILED CODE */

// You can write more code here
