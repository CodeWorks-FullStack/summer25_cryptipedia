import { Profile } from "./Profile.js";

export class CryptidEncounterProfile extends Profile {
  constructor(data) {
    super(data)
    this.cryptidEncounterId = data.cryptidEncounterId
  }
}