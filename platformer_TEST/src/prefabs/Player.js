
// You can write more code here

/* START OF COMPILED CODE */

class Player extends Phaser.GameObjects.Sprite {

	constructor(scene, x, y, texture, frame) {
		super(scene, x ?? 78, y ?? 37, texture || "girl", frame);

		scene.physics.add.existing(this, false);
		this.body.setOffset(15, 0);
		this.body.setSize(30, 100, false);

		/* START-USER-CTR-CODE */

		this.hurtFlag = false;

		this.scene.time.addEvent({
			loop: true,
			delay: 500,
			callback: () => {

				this.hurtFlag = false;
			}
		});

		this.scene.events.on("update", () => this.updatePlayer());

		/* END-USER-CTR-CODE */
	}

	/* START-USER-CODE */

	/**
	 * @return {Phaser.Physics.Arcade.Body} 
	 */
	getBody() {
		return this.body;
	}

	updatePlayer() {

		if (this.hurtFlag) {

			//this.play("player/hurt/player-hurt", true);
		}
	}

	hurtPlayer() {

		if (this.hurtFlag) {

			return;
		}

		this.hurtFlag = true;

		//this.hurtTimer.start();

		const body = this.getBody();

		body.velocity.y = -100;

		body.velocity.x = (this.scale.x == 1) ? -100 : 100;
	}

	/* END-USER-CODE */
}

/* END OF COMPILED CODE */

// You can write more code here
