import { useState } from 'react'
import './App.css'
import { useEffect } from 'react'
import { List, ListItemText, ListItem, Typography } from '@mui/material';
import axios from 'axios';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(()=>{
  //   fetch('https://localhost:5001/api/activities')
  //   .then(response => response.json())
  //   .then(data=> setActivities(data))

  //You can specify the type in the angle brackets of axios
    axios.get<Activity[]>('https://localhost:5001/api/activities')
    .then(response=> setActivities(response.data))

  return ()=> {}
  }, []);

  return(
  <>
  <h2>Hellaurr??</h2>
  <Typography variant='h3'>Reactivities</Typography>
    <List>
    {activities.map((activity)=>(
      <ListItem key={activity.id}>
          <ListItemText>{activity.title}</ListItemText>
      </ListItem>
      ))}
    </List>
  </>)
}

export default App;
