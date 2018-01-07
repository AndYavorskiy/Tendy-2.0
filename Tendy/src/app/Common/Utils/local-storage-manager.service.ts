import * as _ from "lodash";

interface IDictionary {
  key: string;
  value: string;
}

export class LocalStrg {  
  public static set(key: string, value: string) {
    localStorage.setItem(key, value);
  }

  public static setMany(array: IDictionary[]) {
    _.forEach(array, (item) => {
      localStorage.setItem(item.key, item.value);
    })
  }

  public static get(key: string): string {
    return localStorage.getItem(key);
  }

  public static remove(key: string) {
    return localStorage.removeItem(key);
  }

  public static exists(key: string): boolean {
    return !!localStorage.getItem(key);
  }

  public static clear() {
    localStorage.clear();
  }
}
