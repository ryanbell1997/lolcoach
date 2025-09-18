import { makeAutoObservable } from "mobx";

class UserStore {
  name = "";
  tag = "";
  puuid = "";

  constructor() {
    makeAutoObservable(this);
  }

  setName(name: string) {
    this.name = name;
  }

  setTag(tag: string) {
    this.tag = tag;
  }

  setPuuid(puuid: string) {
    this.puuid = puuid;
  }

  reset() {
    this.name = "";
    this.tag = "";
    this.puuid = "";
  }
}

const userStore = new UserStore();
export default userStore;
