function Triangle(num) {
	this.rows = [[1]];
	for (var i = 1; i < num; i++) {
		var row = [1]
		for (var j = 1; j < i; j++) {
			if (i > 1) {
				row.push(this.rows[i - 1][j - 1] + this.rows[i - 1][j])
			}
		}
		row.push(1);
		this.rows.push(row);
	}
	this.lastRow = this.rows[num - 1];
}

module.exports = Triangle;