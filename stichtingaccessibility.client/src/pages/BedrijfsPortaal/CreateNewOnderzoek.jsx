import NewOnderzoekForm from '../../components/NewOnderzoekForm'
import CreateNewUitnodiging from '../../components/CreateNewUitnodiging';


function CreateNewOnderzoek() {
  const [isActive, setIsActive] = useState();
  const OnderzoekInformatieHandler = informatie => {
    
  }
  const GetOnderzoekInformatie = (data) => {
    const gestuurdData = {
      ...data
    }
    console.log(gestuurdData)
  };

  return <>
  <NewOnderzoekForm getInfomatie={GetOnderzoekInformatie}/>
  <CreateNewUitnodiging onderzoekInformatie/>
  </>;
}

export default CreateNewOnderzoek;
