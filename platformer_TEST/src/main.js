
window.addEventListener("load", function () {

	var game = new Phaser.Game({
		width: 288,
		height: 192,
		type: Phaser.AUTO,
		backgroundColor: "#242424",
		scale: {
			mode: Phaser.Scale.FIT,
			autoCenter: Phaser.Scale.CENTER_BOTH
		},
		physics: {
			default: "arcade",
			arcade: {
				debug: false,
				gravity: {
					y: 500
				}
			}
		},
		render: {
			pixelArt: true,
		},
		input: {
			activePointers: 3
		}
	});

	game.scene.add("Boot", Boot, true);
	game.scene.add("Preloader", Preloader);
	game.scene.add("TitleScreen", TitleScreen);
	game.scene.add("Level", Level);
	game.scene.add("GameOver", GameOver);
	game.scene.add("quiz1", quiz1);
	game.scene.add("quiz2", quiz2);
	game.scene.add("quiz3", quiz3);
	game.scene.add("quiz4", quiz4);
	game.scene.add("quiz5", quiz5);
	game.scene.add("GameWin", GameWin);
});

class Boot extends Phaser.Scene {

	preload() {

		this.load.pack("pack", "assets/preload-pack.json");
		this.load.audio("bgm", ["assets/audio/noworries.mp3"]);
	}

	create() {
		this.scene.start("Preloader");
	}
}