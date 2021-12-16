const BASE_PRICE = 800;
const DISCOUNTS = {
  1: 1,
  2: 0.95,
  3: 0.9,
  4: 0.8,
  5: 0.75
};

export const cost = (basket) => {
  if (basket.length === 0)
    return 0;

  let maxDiscount = new Set(basket).size,
    lowestTotal = Number.MAX_VALUE;

  for (; maxDiscount > 0; maxDiscount--) {
    let tmpBasket = basket.slice(),
      tmpTotal = total(tmpBasket, maxDiscount);    

    if (tmpTotal < lowestTotal) 
      lowestTotal = tmpTotal;
  }
  return lowestTotal;
};

const discountPrice = (discountType) => {
  return BASE_PRICE * DISCOUNTS[discountType];
};

const discountTotal = (groupSize) => {
  return groupSize * discountPrice(groupSize);
};

const groupBooks = (books, groupSize) => {
  let group = [...new Set(books)];
  if (group.length > groupSize)
    group.length = groupSize;
  return group;
};

const removeGroupFromBasket = (basket, group) => {
  group.forEach(b => {
    let i = basket.indexOf(b);
    if (i > -1)
      basket.splice(i, 1);
  });
  return basket;
};

const sortBasketIntoGroups = (basket, groupSize) => {
  let groups = [];

  while (basket.length > 0) {
    let tmpGroup = groupBooks(basket, groupSize);        
    groups.push(tmpGroup.length);
    basket = removeGroupFromBasket(basket, tmpGroup);    
  }

  let five = groups.indexOf(5)
    , three = groups.indexOf(3);

  if (five > -1 && three > -1) {
    groups.splice(five, 1, 4);
    groups.splice(three, 1, 4);
  }

  return groups;
};

const total = (basket, discountType) => {
  return sortBasketIntoGroups(basket, discountType)
    .reduce((previous, current) => previous + discountTotal(current) , 0);
};