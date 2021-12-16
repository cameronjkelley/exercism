export class Series {
  constructor(series) {
    this._series = series;
  }

  slices(sliceLength) {
    if (this._series.length === 0) throw new Error('series cannot be empty');
    else if (sliceLength > this._series.length) throw new Error('slice length cannot be greater than series length');
    else if (sliceLength === 0) throw new Error('slice length cannot be zero');
    else if (sliceLength < 0) throw new Error('slice length cannot be negative');
    else {
      let result = [];
      for (let i = 0; i + sliceLength <= this._series.length; i++) {
        result.push(this._series.substring(i, i + sliceLength).split('').map(s => Number(s)));
      }
      return result;
    }
  }
}
