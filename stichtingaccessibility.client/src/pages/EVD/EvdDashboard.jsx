import classes from './EvdDashboard.module.css'
import NewOnderzoekForm from '../../components/NewOnderzoekForm.jsx';
import {Stack, Container, Row, Col} from 'react-bootstrap';

function EvdDashboard() {
    return (
        <Stack gap={4} style={{zIndex: 1}}>
            <Container>
                <Row className="d-flex justify-content-center">
                    <Col xs={12} sm={12} md={10} lg={10} xl={10} style={{zIndex: 1}}>
                        <NewOnderzoekForm/>
                    </Col>
                </Row>
            </Container>
        </Stack>
    );
}

export default EvdDashboard;
