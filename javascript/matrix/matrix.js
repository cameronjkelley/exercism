function Matrix (input) {
	this.rows = 
		input.split("\n")
			.map(row => row.split(" ")
				.map(x => parseInt(x)));
	this.columns = 
		this.rows[0]
			.map((col, i) => this.rows
				.map(row => row[i]));
};

module.exports = Matrix;
