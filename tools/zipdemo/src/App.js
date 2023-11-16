import "./App.css";
import JSZip from "jszip";
import { useEffect, useState } from "react";
import { getPlayersFile } from "./fileapi";
import JSZipUtils from 'jszip-utils';

function App() {
    const [finished, setFinished] = useState(false)
    const [tech, setTech] = useState({});
    const [currentIndex, setCurrentIndex] = useState('62BibaTurnC01')
    const [options, setOptions] = useState([]);

    const extractZip = async (extractedFiles) => {
        const taskMap = new Map();
        console.log(extractedFiles)
        extractedFiles.forEach((relativePath, file) => {
          if (file.dir) {
            return;
          }
          if (!file.name.endsWith('.jpg')) {
            return;
          }

          if (file.name.startsWith('__MACOSX')) {
            return;
          }
          const contentTask = file.async("base64");
          taskMap.set(file.name.split("/")[1], contentTask);
        });

        await Promise.all(taskMap.values());
        console.log("All pictures are loaded");
        const sortedTaskMap = new Map([...taskMap].sort());
        //console.log(sortedTaskMap);

        const techniques = {};
        sortedTaskMap.forEach(async (v, k) => {
            const key = k.split("_")[0];
            techniques[key] = techniques[key] || [];
            techniques[key].push(await v)
        });
        setTech(techniques);
        setOptions(Object.keys(techniques));
        setFinished(true);
      };

    useEffect(() => {
        JSZipUtils.getBinaryContent('https://localhost:7142/Players/test-zip1.zip', function(err, data) {
            if(err) {
                throw err; 
            }
            JSZip.loadAsync(data).then(async extractedFiles => {
                await extractZip(extractedFiles);
            });
        });
    }, [])

  return (
    <div className="App">
      {
        finished && options.map(op => <button onClick={() => setCurrentIndex(op)}>{op}</button>)
      }
      {  
        finished && <img src={`data:image/jpeg;base64,${tech[currentIndex][1]}`} alt="secret"/>
      }
    </div>
  );
}

export default App;
