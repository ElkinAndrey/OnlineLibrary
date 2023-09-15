export const getEmptyArray = (array) => {
  return array === null || array === undefined || array.length === null ? [ null ] : array;
};
