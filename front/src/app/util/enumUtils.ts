export function enumToSelectOptions<T extends { [key: string]: string }>(
  e: T
): { label: string; value: string }[] {
  return Object.entries(e).map(([key, value]) => ({
    label: value,
    value: key
  }));
}
  
  