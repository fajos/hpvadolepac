
// You can write more code here

/* START OF COMPILED CODE */

class Virus extends Phaser.GameObjects.Sprite {

	constructor(scene, x, y, texture, frame) {
		super(scene, x ?? 76, y ?? 31, texture || "virus", frame);
		
		scene.physics.add.existing(this, true);
		this.scaleX = 0.2;
		this.scaleY = 0.2;

		/* START-USER-CTR-CODE */
		// Write your code here.
		/* END-USER-CTR-CODE */
	}

	/* START-USER-CODE */

	// Write your code here.

	/* END-USER-CODE */
}

/* END OF COMPILED CODE */

// You can write more code here
