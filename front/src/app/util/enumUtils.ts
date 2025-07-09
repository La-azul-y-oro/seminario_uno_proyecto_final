export function enumToSelectOptions<T extends { [key: string]: string }>(
  e: T
): { id: string; name: string }[] {
  return Object.entries(e).map(([key, value]) => ({
    name: value,
    id: key
  }));
}
  
  