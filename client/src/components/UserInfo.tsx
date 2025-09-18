import React from "react";
import { observer } from "mobx-react-lite";
import userStore from "../stores/userStore";

const UserInfo = observer(() => (
  <div className="mt-4">
    <h2>User Info (MobX)</h2>
    <div>Name: {userStore.name}</div>
    <div>Tag: {userStore.tag}</div>
    <div>Puuid: {userStore.puuid}</div>
  </div>
));

export default UserInfo;
