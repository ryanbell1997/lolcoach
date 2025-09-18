import { useEffect } from "react"
import userStore from "../stores/userStore"
import { observer } from "mobx-react-lite"

const MatchHistory = observer(() => {
    // const [matches, setMatches] = values([]);


    useEffect(() => {
        // Fetch match history data here
        const fetchData = async () => {
            const response = await fetch(`http://localhost:5058/match/${userStore.puuid}`, {
                method: 'GET'
            });

            const data = await response.json();
            console.log(data);
        };
        fetchData();
    }, [])


    return (
        <>
         <h1>Match History</h1>
         <p>Players most recent match history.</p>
        </>
    )
});

export default MatchHistory