import { useEffect, useState } from "react";
import axios from "axios";
import { Header, List } from "semantic-ui-react";

const App = () => {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/Activities").then((response) => {
      console.log(response);
      setActivities(response.data);
    });
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Reactivities" />
      <List>
        {activities.map((activity: any) => (
          <li key={activity.id}>{activity.name}</li>
        ))}
      </List>
    </div>
  );
};

export default App;
