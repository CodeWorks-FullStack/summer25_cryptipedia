import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { CryptidEncounterProfile } from "@/models/CryptidEncounterProfile.js"

class CryptidEncountersService {
  async deleteCryptidEncounter(cryptidEncounterId) {
    const response = await api.delete(`api/cryptidEncounters/${cryptidEncounterId}`)
    logger.log('DELETED ENCOUNTER ❌🐸', response.data)
    const profiles = AppState.cryptidEncounterProfiles
    const index = profiles.findIndex(profile => profile.cryptidEncounterId == cryptidEncounterId)
    profiles.splice(index, 1)
    AppState.cryptid.encounterCount--
  }
  async createCryptidEncounter(encounterData) {
    const response = await api.post('api/cryptidEncounters', encounterData)
    logger.log('CREATED ENCOUNTER 🐸', response.data)
    AppState.cryptidEncounterProfiles.push(new CryptidEncounterProfile(response.data))
    AppState.cryptid.encounterCount++
  }
  async getCryptidEncounterProfilesByCryptidId(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}/cryptidEncounters`)
    logger.log('GOT PROFILES', response.data)
    AppState.cryptidEncounterProfiles = response.data.map(pojo => new CryptidEncounterProfile(pojo))
  }
}

export const cryptidEncountersService = new CryptidEncountersService()