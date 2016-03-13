var utils = module.exports;

utils.getProcRet = function(row, fieldName, idx){
	fieldName = typeof fieldName !== 'undefined' ? fieldName : 'ret';
	idx = typeof idx !== 'undefined' ? idx : 0;
	try{
		return row[idx][0][fieldName];
	}catch(err) {
		return undefined;
	}
};

utils.getProcRetArr = function(row, fieldName){
	fieldName = typeof fieldName !== 'undefined' ? fieldName : 'ret';
	try{
		var arr = [];
		for (var i = 0; i < row[0].length; i++) {
			arr.push(row[0][i][fieldName]);
		};
		return arr;
	}catch(err) {
		return undefined;
	}
}



utils.getProcRetObj = function(row, fieldNameArr){
	try{
		var obj = {};
		for (var j = 0; j < fieldNameArr.length; j++) {
			obj[fieldNameArr[j]] = row[0][0][fieldNameArr[j]];
		};
		return obj;
	}catch(err) {
		return undefined;
	}
}

utils.getProcRetObjArr = function(row, fieldNameArr){
	try{
		var arr = [];
		for (var i = 0; i < row[0].length; i++) {
			var obj = {};
			for (var j = 0; j < fieldNameArr.length; j++) {
				obj[fieldNameArr[j]] = row[0][i][fieldNameArr[j]];
			};
			arr.push(obj);
		};
		return arr;
	}catch(err) {
		return undefined;
	}
}
